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