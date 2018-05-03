/*
 Generate Session
*/

String secret = "a1b2c3d4e5f6g7h8i9j0";
String userId = "vpaas@kaltura.com";
KalturaSessionType type = KalturaSessionType.ADMIN;
int partnerId = 9876543;
int expiry = 86400;
String privileges = "";

Object result = client.getSessionService().start(secret, userId, type, partnerId, expiry, privileges);
System.out.println(result);

/*
 Ingestion
*/

KalturaMediaEntry entry = new KalturaMediaEntry();
entry.mediaType = KalturaMediaType.IMAGE;
entry.name = "Cat";

Object entryResult = client.getMediaService().add(entry);

String entryId = entryResult.id;
KalturaUrlResource resource = new KalturaUrlResource();
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

Object result = client.getMediaService().addContent(entryId, resource);
System.out.println(result);