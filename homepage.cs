/*
  Generate Session 
*/

string secret = "a1b2c3d4e5f6g7h8i9j0";
string userId = "vpaas@kaltura.com";
SessionType type = SessionType.ADMIN;
int partnerId = 9876543;
int expiry = 86400;
string privileges = "";

OnCompletedHandler<string> handler = new OnCompletedHandler<string>(
      (string result, Exception e) =>
      {
        CodeExample.PrintObject(result);
        done = true;
      });
SessionService.Start(secret, userId, type, partnerId, expiry, privileges)
   .SetCompletion(handler)
   .Execute(client);
   
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