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


---

## Chat System Usage Notes

### **ReadCursors Functionality**
- Tracks last read timestamp per user
- Update when user opens chat or scrolls to message
- Check unread: `message.createdAt > readCursors[userId]`
- Set initial: `conversation.createdAt` or `null`
- Recalculate `unreadCounts` after updating readCursor

### **Conversation Management**
- Each ad can have multiple conversations with different users
- `participants` array contains user IDs involved in conversation
- `participantInfo` contains cached user details for performance
- `relatedAd` contains cached ad information
- `unreadCounts` tracks unread messages per user
- `status` manages conversation lifecycle

### **Message Flow**
- Messages reference conversation via `conversationId`
- `senderId` identifies message author
- `contentType` determines message format (text, image, voice)
- `createdAt` timestamp used for ordering and read tracking

### **MongoDB Indexes**
```javascript
// For user's chat list
db.conversations.createIndex({ 
  "participants": 1, 
  "lastMessage.timestamp": -1 
});

// For message queries
db.messages.createIndex({ 
  "conversationId": 1, 
  "timestamp": -1 
});

// For ad-related conversations
db.conversations.createIndex({ 
  "relatedAd.id": 1 
});
```