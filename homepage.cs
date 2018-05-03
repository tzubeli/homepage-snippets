
/*
  Ingestion 
*/

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


String entryId = ;//todo 
KalturaUrlResource resource = new KalturaUrlResource();
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

OnCompletedHandler<MediaEntry> handler = new OnCompletedHandler<MediaEntry>(
      (MediaEntry result, Exception e) =>
      {
        CodeExample.PrintObject(result);
        done = true;
      });
MediaService.AddContent(entryId, resource)
   .SetCompletion(handler)
   .Execute(client);