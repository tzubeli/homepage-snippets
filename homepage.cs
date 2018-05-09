/*
Generate Session 
*/


Configuration config = new Configuration();
Client client = new Client(config);
client.KS = client.GenerateSession(partnerId, secret, userId, type, expiry, privileges);

string secret = "a1b2c3d4e5f6g7h8i9j0";
string userId = "you@email.com";
SessionType type = SessionType.ADMIN;
int partnerId = 0000000;
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

Configuration config = new Configuration();
Client client = new Client(config);
client.KS = client.GenerateSession(partnerId, secret, userId, type, expiry, privileges);

MediaEntry entry = new MediaEntry();
entry.MediaType = MediaType.VIDEO;
entry.Name = "Cat";

OnCompletedHandler<MediaEntry> handler = new OnCompletedHandler<MediaEntry>(
  (MediaEntry result, Exception e) =>
  {
    String entryId = result.id;
    KalturaUrlResource resource = new KalturaUrlResource();
    resource.url = "https://example.com/catVideo.mp4";

    OnCompletedHandler<MediaEntry> handler = new OnCompletedHandler<MediaEntry>(
      (MediaEntry result, Exception e) =>
      {
        CodeExample.PrintObject(result);
        done = true;
        });
    MediaService.AddContent(entryId, resource)
    .SetCompletion(handler)
    .Execute(client);
    done = true;
    });
MediaService.Add(entry)
.SetCompletion(handler)
.Execute(client);


/*
Thumb Asset  
*/


Configuration config = new Configuration();
Client client = new Client(config);
client.KS = client.GenerateSession(partnerId, secret, userId, type, expiry, privileges);

string entryId = "xyz_123";
UrlResource contentResource = new UrlResource();
contentResource.Url = "https://example.com/catThumbnail.jpeg";
ThumbAsset thumbAsset = new ThumbAsset();

OnCompletedHandler<ThumbAsset> handler = new OnCompletedHandler<ThumbAsset>(
(ThumbAsset result, Exception e) =>
{
  OnCompletedHandler<ThumbAsset> handler = new OnCompletedHandler<ThumbAsset>(
    (ThumbAsset result, Exception e) =>
    {
      CodeExample.PrintObject(result);
      done = true;
      });
  ThumbAssetService.SetContent(result.id, contentResource)
  .SetCompletion(handler)
  .Execute(client);

  CodeExample.PrintObject(result);
  done = true;
  });
ThumbAssetService.Add(entryId, thumbAsset)
.SetCompletion(handler)
.Execute(client);


/*
User 
*/

Configuration config = new Configuration();
Client client = new Client(config);
client.KS = client.GenerateSession(partnerId, secret, userId, type, expiry, privileges);

User user = new User();
user.Email = "you@email.com";
user.Id = "username";

OnCompletedHandler<User> handler = new OnCompletedHandler<User>(
  (User result, Exception e) =>
  {
    CodeExample.PrintObject(result);
    done = true;
    });
UserService.Add(user)
.SetCompletion(handler)
.Execute(client);


/*
Search 
*/


Configuration config = new Configuration();
Client client = new Client(config);
client.KS = client.GenerateSession(partnerId, secret, userId, type, expiry, privileges);

ESearchEntryParams searchParams = new ESearchEntryParams();
searchParams.SearchOperator = new ESearchEntryOperator();
searchParams.SearchOperator.Operator = ESearchOperatorType.AND_OP;
searchParams.SearchOperator.SearchItems = new List<ESearchEntryBaseItem>();
searchParams.SearchOperator.SearchItems.Add(new ESearchUnifiedItem());
searchParams.SearchOperator.SearchItems[0].ItemType = ESearchItemType.PARTIAL;
searchParams.SearchOperator.SearchItems[0].SearchTerm = "cat";

OnCompletedHandler<ESearchResponse> handler = new OnCompletedHandler<ESearchResponse>(
  (ESearchResponse result, Exception e) =>
  {
    CodeExample.PrintObject(result);
    done = true;
    });
ESearchService.SearchEntry(searchParams)
.SetCompletion(handler)
.Execute(client);
