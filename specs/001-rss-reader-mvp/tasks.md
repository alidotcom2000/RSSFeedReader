# Tasks: RSS Reader MVP

**Input**: Design documents from `/specs/001-rss-reader-mvp/`

**Prerequisites**: plan.md (required), spec.md (required for user stories), research.md, data-model.md, contracts/

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2, US3)
- Include exact file paths in descriptions

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the backend/frontend project structure and local configuration needed for the MVP.

- [ ] T001 Create backend and frontend project structure under backend/RSSFeedReader.Api/ and frontend/RSSFeedReader.UI/
- [ ] T002 Initialize the .NET solution and reference the backend API and Blazor WebAssembly frontend projects
- [ ] T003 [P] Configure startup ports and local run settings in backend/RSSFeedReader.Api/Properties/launchSettings.json and frontend/RSSFeedReader.UI/Properties/launchSettings.json

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Establish the shared API, UI, and in-memory data flows required before any user story work begins.

**⚠️ CRITICAL**: No user story work can begin until this phase is complete.

- [ ] T004 Configure the backend API startup pipeline in backend/RSSFeedReader.Api/Program.cs
- [ ] T005 [P] Configure frontend bootstrapping and API base URL in frontend/RSSFeedReader.UI/Program.cs and frontend/RSSFeedReader.UI/wwwroot/appsettings.json
- [ ] T006 [P] Configure CORS and allowed frontend origins in backend/RSSFeedReader.Api/Program.cs
- [ ] T007 Create the Subscription model in backend/RSSFeedReader.Api/Models/Subscription.cs with the required fields: `id`, `url`, and `createdAt`
- [ ] T008 Create the in-memory subscription service in backend/RSSFeedReader.Api/Services/SubscriptionService.cs for add/list behavior
- [ ] T009 Add validation rules for empty or whitespace-only values and preserve existing subscriptions when new entries are added in backend/RSSFeedReader.Api/Services/SubscriptionService.cs

**Checkpoint**: Foundation ready - user story implementation can now begin in parallel.

---

## Phase 3: User Story 1 - Add a subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to add a feed URL and immediately see it appear in their subscription list.

**Independent Test**: A user can enter a URL, submit it, and confirm it appears in the list without leaving the page.

### Implementation for User Story 1

- [ ] T010 [P] [US1] Add the GET and POST subscription endpoints in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs
- [ ] T011 [P] [US1] Create the subscription form component in frontend/RSSFeedReader.UI/Components/SubscriptionForm.razor
- [ ] T012 [P] [US1] Create the subscription list display component in frontend/RSSFeedReader.UI/Components/SubscriptionList.razor
- [ ] T013 [US1] Implement the submit flow and immediate list refresh in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor
- [ ] T014 [US1] Add the frontend API client for fetching and posting subscriptions in frontend/RSSFeedReader.UI/Services/SubscriptionClient.cs
- [ ] T015 [US1] Verify route and startup health by removing template demo conflicts and confirming the chosen MVP page is the only root route in frontend/RSSFeedReader.UI/Pages/
- [ ] T016 [US1] Run the manual smoke validation for the add-subscription flow from quickstart.md and confirm it matches the MVP acceptance criteria

**Checkpoint**: At this point, User Story 1 should be fully functional and testable independently.

---

## Phase 4: User Story 2 - Review subscriptions (Priority: P2)

**Goal**: Show the user the current subscription list and its starting state clearly.

**Independent Test**: A user can open the app and see either an empty state or the current list of added feed URLs.

### Implementation for User Story 2

- [ ] T017 [P] [US2] Add the empty state and list display logic in frontend/RSSFeedReader.UI/Pages/Subscriptions.razor
- [ ] T018 [P] [US2] Ensure the list remains stable across repeated additions in frontend/RSSFeedReader.UI/Components/SubscriptionList.razor
- [ ] T019 [US2] Keep the API response format consistent with the contract in backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs and contracts/subscriptions-api.md
- [ ] T020 [US2] Run the review-subscriptions validation scenario from quickstart.md and confirm the list reflects the added entries accurately

**Checkpoint**: At this point, User Stories 1 and 2 should both work independently.

---

## Phase 5: User Story 3 - Keep the MVP scope disciplined (Priority: P3)

**Goal**: Prevent scope creep by keeping the feature focused on subscription management only.

**Independent Test**: A feature review confirms that feed fetching, parsing, persistence, and polling remain outside the MVP implementation.

### Implementation for User Story 3

- [ ] T021 [P] [US3] Confirm the backend startup path stays limited to add/list operations in backend/RSSFeedReader.Api/Program.cs
- [ ] T022 [P] [US3] Confirm the frontend does not introduce feed parsing or item display paths in frontend/RSSFeedReader.UI/Pages/ and frontend/RSSFeedReader.UI/Components/
- [ ] T023 [US3] Validate the project stays aligned with the MVP charter and constitution by reviewing StakeholderDocuments/ProjectGoals.md, StakeholderDocuments/AppFeatures.md, and the constitution in .specify/memory/constitution.md
- [ ] T024 [US3] Run the final MVP boundary check and document any out-of-scope features as deferred follow-up work

**Checkpoint**: All user stories should now be independently functional and scope-compliant.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Final cleanup, validation, and release-readiness checks for the MVP.

- [ ] T025 [P] Review and simplify inline comments and documentation in backend/RSSFeedReader.Api/ and frontend/RSSFeedReader.UI/
- [ ] T026 [P] Update project documentation in backend/README.md and frontend/README.md for the subscription-only MVP
- [ ] T027 Run the full quickstart validation sequence from specs/001-rss-reader-mvp/quickstart.md and confirm all required checks pass
- [ ] T028 Final code review for configuration, route health, and startup consistency before declaring the MVP ready

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately.
- **Foundational (Phase 2)**: Depends on Setup completion and blocks all user stories.
- **User Stories (Phase 3+)**: All depend on Foundational completion.
- **Polish (Phase 6)**: Depends on all desired user stories being complete.

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational completion and is the primary MVP deliverable.
- **User Story 2 (P2)**: Can start after Foundational completion; it builds on the same API and UI contract but remains independently testable.
- **User Story 3 (P3)**: Can start after Foundational completion and is focused on scope discipline rather than feature growth.

### Parallel Opportunities

- Setup tasks T001-T003 can run in parallel.
- Foundational tasks T005-T006 can run in parallel once the base project structure is in place.
- User Story 1 implementation tasks T010-T012 can proceed in parallel once the foundational API and frontend wiring exist.
- User Story 2 tasks T017-T018 can run in parallel after the main subscription flow is working.
- User Story 3 tasks T021-T022 can run in parallel once the MVP is functionally stable.

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Complete Phase 1: Setup.
2. Complete Phase 2: Foundational.
3. Complete Phase 3: User Story 1.
4. Validate the add-subscription workflow from the quickstart.
5. Stop and confirm the MVP is ready before adding any broader capabilities.

### Incremental Delivery

1. Complete Setup + Foundational.
2. Deliver User Story 1 to establish the MVP.
3. Add User Story 2 to improve list visibility and clarity.
4. Add User Story 3 to maintain scope discipline and keep the project aligned to the charter.
5. Finish with polish and validation across the full MVP path.

### Parallel Team Strategy

With multiple developers:

1. Team completes Setup + Foundational together.
2. Developer A works on User Story 1 backend and API wiring.
3. Developer B works on User Story 1 frontend UI and list behavior.
4. Developer C focuses on User Story 2 review flow and User Story 3 scope checks.
5. Final validation runs after all story work is integrated.

---

## Notes

- [P] tasks are different files or independent workstreams with no dependency on incomplete tasks.
- [Story] labels map tasks to their user story for traceability.
- This MVP intentionally excludes feed parsing, persistence, and background refresh.
- The tasks are designed to be executed after the plan and contract artifacts are approved.
