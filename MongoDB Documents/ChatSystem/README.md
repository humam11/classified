# Chat System Documentation

## Conversation Schema
- `participants`: Array of user IDs
- `participantInfo`: User details (firstName, profilePictureUrl, lastSeen)
- `relatedAd`: Associated advertisement details
- `lastMessage`: Most recent message info
- `unreadCounts`: Unread messages per user
- `readCursors`: Last read timestamp per user
- `status`: "active", "deleted", or "archived"

## readCursors Usage
- Tracks last read timestamp per user
- Update when user opens chat or scrolls to message
- Check unread: `message.createdAt > readCursors[userId]`
- Set initial: `conversation.createdAt` or `null`
- Recalculate `unreadCounts` after updating readCursor

## Message Schema
- `conversationId`: Reference to conversation
- `senderId`: Message sender
- `contentType`: 0=text, 1=image, 2=file, 3=voice, 4=video
- `content`: Message content
- `createdAt`: Timestamp 