MediaEntry entry = new MediaEntry();
entry.MediaType = MediaType.IMAGE;
entry.Name = "Cat";

OnCompletedHandler<MediaEntry> handler = new OnCompletedHandler<MediaEntry>(
      (MediaEntry result, Exception e) =>
      {
        CodeExample.PrintObject(result);
        done = true;
      });
MediaService.Add(entry)
   .SetCompletion(handler)
   .Execute(client);

 String entryId = "1_09d6if4y";
KalturaUrlResource resource = new KalturaUrlResource();
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

Object result = client.getMediaService().addContent(entryId, resource);
System.out.println(result);