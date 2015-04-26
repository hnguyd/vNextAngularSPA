'use strict';
app.controller('placesPhotosCtrl', function ($scope, $modal, venueName, venuePhotos) {

	$scope.venueName = venueName;
	$scope.venuePhotos = venuePhotos;

	$scope.close = function () {
		$modal.dismiss('cancel');
	};

	$scope.buildVenuePhoto = function (photo) {

		return photo.prefix + '256x256' + photo.suffix;
	};
});