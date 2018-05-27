#
# Generate Session
#

secret = "a1b2c3d4e5f6g7h8i9j0"
userId = "you@email.com"
type = KalturaSessionType.ADMIN
partnerId = 0000000
expiry = 86400
privileges = ""

result = client.session.start(secret, userId, type, partnerId, expiry, privileges);
print(result);


#
# Ingestion
#

entry = KalturaMediaEntry()
entry.mediaType = KalturaMediaType.VIDEO
entry.name = "Cat"
entryResult = client.media.add(entry);

entryId = entryResult.id; 
resource = KalturaUrlResource()
resource.url = "https://example.com/catVideo.mp4"
result = client.media.addContent(entryId, resource);


#
# User
#


user = KalturaUser()
user.email = "you@email.com"
user.id = "username"

result = client.user.add(user);
print(result);



#
# Search 
#
searchParams = KalturaESearchEntryParams()
searchParams.searchOperator = KalturaESearchEntryOperator()
searchParams.searchOperator.searchItems = []
searchParams.searchOperator.searchItems[0] = KalturaESearchUnifiedItem()
searchParams.searchOperator.searchItems[0].addHighlight = True
searchParams.searchOperator.searchItems[0].searchTerm = "cat"

result = client.elasticsearch.eSearch.searchEntry(searchParams);
print(result);


#
# Thumb Asset 
# 


entry_id = 'xyz_123'
resource = KalturaUrlResource()
resource.url = "https://example.com/catThumbnail.jpeg"

thumbAsset = new KalturaThumbAsset()

result = client.thumbAsset.add(entry_id, thumbAsset);
client.thumbAsset.setContent(result.id, resource); 


