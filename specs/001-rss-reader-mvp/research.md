# Research: RSS Reader MVP

## Decision

The MVP will be implemented as a two-tier web application with an ASP.NET Core Web API backend and a Blazor WebAssembly frontend. The backend provides the in-memory subscription API, while the frontend handles user input and list display.

## Rationale

This choice matches the project technology documents and supports the stated goal of a lightweight proof-of-concept. It also aligns with the constitution by keeping boundaries clear, limiting scope, and preserving room for later feature expansion without a rewrite.

## Alternatives considered

- Single-page app with all logic local only: rejected because the project documents explicitly define a backend and frontend split.
- Full feed-fetching MVP with RSS parsing and persistence: rejected because it violates the MVP scope and adds production complexity before the add-subscription workflow is proven.
- A database-backed implementation at the start: rejected because the MVP requirement explicitly allows in-memory storage and the constitution enforces incremental delivery.

## Unknowns resolved

- Need for validation: user-submitted feed URLs will be treated as provided values; validation remains intentionally minimal for the MVP.
- Need for persistence: not required in this phase; the data model is session-scoped only.
- Need for feed rendering: deferred beyond the MVP and treated as a separate approved feature.

## Follow-up guidance

Future work may add feed retrieval, parsing, validation, persistence, and automatic refresh only after the add-subscription flow is stable and accepted in a later phase.
