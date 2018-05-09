#
# Generate Session
#

secret = "a1b2c3d4e5f6g7h8i9j0"
user_id = "you@email.com"
type = KalturaSessionType::ADMIN
partner_id = 0000000
expiry = 86400
privileges = ""

results = client.session_service.start(secret, user_id, type, partner_id, expiry, privileges)
puts results.inspect

#
# Ingestion
#

config = KalturaConfiguration.new()
client = KalturaClient.new(config)
client.setKs(ks)

entry = KalturaMediaEntry.new()
entry.media_type = KalturaMediaType::VIDEO
entry.name = "Cat"

results = client.media_service.add(entry)
puts results.inspect

entry_id = results.id
resource = KalturaUrlResource.new()
resource.url = "https://example.com/catVideo.mp4"

results = client.media_service.add_content(entry_id, resource)
puts results.inspect

#
# User
#

config = KalturaConfiguration.new()
client = KalturaClient.new(config)
client.setKs(ks)

user = KalturaUser.new()
user.email = "you@email.com"
user.id = "username"

results = client.user_service.add(user)
puts results.inspect

#
# Search
#

config = KalturaConfiguration.new()
client = KalturaClient.new(config)
client.setKs(ks)

search_params = KalturaESearchEntryParams.new()
search_params.search_operator = KalturaESearchEntryOperator.new()
search_params.search_operator.operator = KalturaESearchOperatorType::AND_OP
search_params.search_operator.search_items = []
search_params.search_operator.search_items[0] = KalturaESearchUnifiedItem.new()
search_params.search_operator.search_items[0].item_type = KalturaESearchItemType::PARTIAL
search_params.search_operator.search_items[0].search_term = "cat"

results = client.e_search_service.search_entry(search_params)
puts results.inspect

# 
# Thumb asset 
#

config = KalturaConfiguration.new()
client = KalturaClient.new(config)
client.setKs(ks)

entry_id = "xyz_123"
resource = KalturaUrlResource.new()
resource.url = "https://example.com/catThumbnail.jpeg"

thumbAsset = KalturaThumbAsset.new()
result = client.thumb_asset_service.add(entry_id, thumbAsset)
client.thumb_asset_service.set_content(result.id, resource)

