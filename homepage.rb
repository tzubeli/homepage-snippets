#
# Generate Session
#

secret = "a1b2c3d4e5f6g7h8i9j0"
user_id = "vpaas@kaltura.com"
type = KalturaSessionType::ADMIN
partner_id = 9876543
expiry = 86400
privileges = ""

results = client.session_service.start(secret, user_id, type, partner_id, expiry, privileges)
puts results.inspect
#
# Ingestion
#

entry = KalturaMediaEntry.new()
entry.media_type = KalturaMediaType::IMAGE
entry.name = "Cat"

results = client.media_service.add(entry)
puts results.inspect

entry_id = results.id
resource = KalturaUrlResource.new()

results = client.media_service.add_content(entry_id, resource)
puts results.inspect