<?php

/* 
 * Generate Session 
 */ 

$secret = "a1b2c3d4e5f6g7h8i9j0";
$userId = "you@email.com";
$type = KalturaSessionType::ADMIN;
$partnerId = 0000000;
$expiry = 86400;
$privileges = "";

$result = $client->session->start($secret, $userId, $type, $partnerId, $expiry, $privileges);
var_dump($result);

/* 
 * Ingestion 
 */ 

$entry = new KalturaMediaEntry();
$entry->mediaType = KalturaMediaType::VIDEO;
$entry->name = "Cat";

$entryResult = $client->media->add($entry);

$entryId = $entryResult->id;
$resource = new KalturaUrlResource();
$resource->url = "https://example.com/catVideo.mp4";

$result = $client->media->addContent($entryId, $resource);
var_dump($result);


/* 
 * Search 
 */ 

$elasticSearchPlugin = KalturaElasticSearchClientPlugin::get($client);
$searchParams = new KalturaESearchEntryParams();
$searchParams->searchOperator = new KalturaESearchEntryOperator();
$searchParams->searchOperator->searchItems = [];
$searchParams->searchOperator->searchItems[0] = new KalturaESearchUnifiedItem();
$searchParams->searchOperator->searchItems[0]->itemType = KalturaESearchItemType::PARTIAL;
$searchParams->searchOperator->searchItems[0]->searchTerm = "cat";

$result = $elasticSearchPlugin->eSearch->searchEntry($searchParams);

/* 
 * Thumb asset 
 */ 

$entry_id = 'xyz_123'
$resource = new KalturaUrlResource();
$resource->url = "https://example.com/catThumbnail.jpeg";

$thumbAsset = new KalturaThumbAsset();
$result = $client->thumbAsset->add($entry_id, $thumbAsset);

$client->thumbAsset->setContent($result->id, $resource);


/* 
 * user
 */ 

$user = new KalturaUser();
$user->email = "you@email.com";
$user->id = "username";

$result = $client->user->add($user);
