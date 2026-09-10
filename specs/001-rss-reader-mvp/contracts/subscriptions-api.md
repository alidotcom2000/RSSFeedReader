# Subscription API Contract

## Overview

The API exposes the minimal functionality required for the MVP subscription workflow.

## Endpoints

### GET /api/subscriptions

Returns the list of active subscriptions for the current session.

**Response**:

```json
[
  "https://example.com/feed.xml",
  "https://example.org/rss"
]
```

### POST /api/subscriptions

Adds a new feed URL to the active list.

**Request body**:

```json
{
  "url": "https://example.com/feed.xml"
}
```

**Success response**:

```json
{
  "id": "unique-id",
  "url": "https://example.com/feed.xml"
}
```

**Validation notes**:

- Empty or whitespace-only values are rejected.
- Duplicate handling is product-defined but should be stable and predictable.

## Notes

This contract intentionally supports only the MVP scope and does not define fetching, parsing, or item retrieval.
