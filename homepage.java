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
entry.mediaType = KalturaMediaType.VIDEO;
entry.name = "Cat";

Object entryResult = client.getMediaService().add(entry);

String entryId = entryResult.id;
KalturaUrlResource resource = new KalturaUrlResource();
resource.url = "https://example.com/catVideo.mp4";

Object result = client.getMediaService().addContent(entryId, resource);
System.out.println(result);


/*
 User
*/


User user = new User();
user.setEmail("amanda.harris@gmail.com");
user.setId("amandaharris");

AddUserBuilder requestBuilder = UserService.add(user); 

/*
 Search
*/

ESearchEntryParams searchParams = new ESearchEntryParams();
searchParams.setSearchOperator(new ESearchEntryOperator());
searchParams.getSearchOperator().setSearchItems(new ArrayList<ESearchEntryBaseItem>(1));
searchParams.getSearchOperator().getSearchItems().set(0, new ESearchUnifiedItem());
searchParams.getSearchOperator().getSearchItems().get(0).setAddHighlight(true);
searchParams.getSearchOperator().getSearchItems().get(0).setSearchTerm("cat");

SearchEntryESearchBuilder requestBuilder = ESearchService.searchentry(searchParams);


/*
 Thumb Asset
*/

String entryId = 'xyz_123'; 
KalturaUrlResource resource = new KalturaUrlResource();
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

ThumbAsset thumbAsset = new KalturaThumbAsset();
Object result = client.thumbAsset.add(entry_id, thumbAsset); 
client.thumbAsset.setContent(result.id, resource); 


