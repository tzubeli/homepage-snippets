entry = KalturaMediaEntry.new()
entry.media_type = KalturaMediaType::IMAGE
entry.name = "Cat"

results = client.media_service.add(entry)
puts results.inspect

String entryId = "1_09d6if4y";
KalturaUrlResource resource = new KalturaUrlResource();
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

Object result = client.getMediaService().addContent(entryId, resource);
System.out.println(result);