'use strict';
app.controller('confirmModalCtrl', function ($scope, $modal, title, message) {

	$scope.title = title;
	$scope.message = message;

	$scope.close = function () {
		$modal.dismiss('cancel');
	};
});