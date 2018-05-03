<?php

/* 
 * Generate Session 
 */ 

$secret = "a1b2c3d4e5f6g7h8i9j0";
$userId = "vpaas@kaltura.com";
$type = KalturaSessionType::ADMIN;
$partnerId = 9876543;
$expiry = 86400;
$privileges = "";

$result = $client->session->start($secret, $userId, $type, $partnerId, $expiry, $privileges);
var_dump($result);

/* 
 * Ingestion 
 */ 

$entry = new KalturaMediaEntry();
$entry->mediaType = KalturaMediaType::IMAGE;
$entry->name = "Cat";

$entryResult = $client->media->add($entry);

$entryId = $entryResult->id;
$resource = new KalturaUrlResource();
$resource->url = "https://orig00.deviantart.net/f3c7/f/2016/008/7/c/a_kitty_cat_7_by_killermiaw-d9n6j90.jpg";

$result = $client->media->addContent($entryId, $resource);
var_dump($result);



