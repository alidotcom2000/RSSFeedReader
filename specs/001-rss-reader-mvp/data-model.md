# Data Model: RSS Reader MVP

## Core Entities

### Subscription

Represents a feed source that the user wants to track in the MVP.

- `id`: unique identifier for the subscription entry
- `url`: the feed URL supplied by the user
- `createdAt`: time the subscription was added

### SubscriptionList

Represents the in-memory set of active subscriptions for the current user session.

- `subscriptions`: ordered collection of Subscription items
- `count`: number of currently stored subscriptions

## Relationships

- A `SubscriptionList` contains zero or more `Subscription` items.
- Each `Subscription` belongs to exactly one active list in the current session.

## Validation Rules

- A subscription URL must be non-empty after trimming whitespace.
- The list must preserve previously added subscriptions when a new one is created.
- Duplicate handling remains a product decision but should be consistent and stable for the MVP.

## State Considerations

The app is intentionally session-scoped and does not persist data across restarts. No long-lived state or background refresh status is included in the MVP.
