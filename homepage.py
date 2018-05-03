entry = KalturaMediaEntry()
entry.mediaType = KalturaMediaType.IMAGE
entry.name = "Cat"
entryResult = client.media.add(entry);

entryId = entryResult.id; 
resource = KalturaUrlResource()
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg"
result = client.media.addContent(entryId, resource);