<?php

require_once('../KalturaPHP5/KalturaClient.php');

$config = new KalturaConfiguration(2365491);
$client = new KalturaClient($config);
$ks = $client->session->start(
"afc50d0a340f5f543d2c349ab0e8c56d",
"avital.tzubeli@kaltura.com",
KalturaSessionType::ADMIN,
2365491, 
86400, 
"disableentitlement");
$client->setKS($ks); 



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

/* 
 * Generate Session 
 */ 



