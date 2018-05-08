
/* 
 * Generate Session 
 */

let secret = "a1b2c3d4e5f6g7h8i9j0";
let userId = "vpaas@kaltura.com";
let type = kaltura.enums.SessionType.ADMIN;
let partnerId = 9876543;
let expiry = 86400;
let privileges = "";

kaltura.services.session.start(secret, userId, type, partnerId, expiry, privileges)
.execute(client)
.then(result => {
    console.log(result);
});


/* 
 * Ingestion 
 */

let entry = new kaltura.objects.MediaEntry();
entry.mediaType = kaltura.enums.MediaType.VIDEO;
entry.name = "Cat";

kaltura.services.media.add(entry)
.execute(client)
.then(result => {
    console.log(result);

	let entryId = result.id;
	let resource = new kaltura.objects.UrlResource();
	resource.url = "https://example.com/catVideo.mp4";

	kaltura.services.media.addContent(entryId, resource)
	.execute(client)
	.then(result => {
	    console.log(result);
	});
});


/* 
 * Thumb Asset 
 */


let entryId = 'xyz_123'
let resource = new kaltura.objects.UrlResource();
resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

let thumbAsset = new kaltura.objects.ThumbAsset();

kaltura.services.thumbAsset.add(entryId, thumbAsset)
.execute(client)
.then(result => {
    kaltura.services.thumbAsset.setContent(result.id, resource);
});


/* 
 * User 
 */


let user = new kaltura.objects.User();
user.email = "amanda.harris@gmail.com";
user.id = "amandaharris";

kaltura.services.user.add(user)
.execute(client)
.then(result => {
    console.log(result);
});


/* 
 * Search 
 */


let searchParams = new kaltura.objects.ESearchEntryParams();
searchParams.searchOperator = new kaltura.objects.ESearchEntryOperator();
searchParams.searchOperator.searchItems = [];
searchParams.searchOperator.searchItems[0] = new kaltura.objects.ESearchUnifiedItem();
searchParams.searchOperator.searchItems[0].addHighlight = true;
searchParams.searchOperator.searchItems[0].searchTerm = "cat";

kaltura.services.eSearch.searchEntry(searchParams)
.execute(client)
.then(result => {
    console.log(result);
});