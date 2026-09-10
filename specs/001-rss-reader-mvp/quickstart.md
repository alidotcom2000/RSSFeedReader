# Quickstart Validation Guide

## Prerequisites

- The backend project is running locally.
- The frontend project is running locally.
- The frontend API base URL matches the backend configuration.
- The CORS configuration allows the frontend origin.

## Validation scenarios

### 1. Add a subscription

1. Open the application in a browser.
2. Enter a valid feed URL in the subscription input.
3. Submit the form.
4. Confirm the new URL appears in the list.

**Expected outcome**: the UI updates immediately and the list contains the newly added subscription.

### 2. Review current subscriptions

1. Add multiple valid feed URLs in sequence.
2. Observe the list after each submission.

**Expected outcome**: all previous subscriptions remain visible and the new one is appended.

### 3. Verify configuration health

1. Confirm the backend listens on the configured port.
2. Confirm the frontend points to the correct API base URL.
3. Confirm browser developer tools show no console-level connection issue.

**Expected outcome**: all local configuration checks pass before the feature is considered ready for manual acceptance testing.

## Scope boundary

This guide validates only the MVP add-subscription workflow. Feed fetching, parsing, and item display remain out of scope in this phase.
