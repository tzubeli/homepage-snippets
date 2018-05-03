
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
entry.mediaType = kaltura.enums.MediaType.IMAGE;
entry.name = "Cat";

kaltura.services.media.add(entry)
.execute(client)
.then(result => {
    console.log(result);

	let entryId = result.id;
	let resource = new kaltura.objects.UrlResource();
	resource.url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

	kaltura.services.media.addContent(entryId, resource)
	.execute(client)
	.then(result => {
	    console.log(result);
	});
});