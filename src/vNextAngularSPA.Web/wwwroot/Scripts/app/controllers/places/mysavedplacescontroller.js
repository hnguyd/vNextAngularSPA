'use strict';
app.controller('MySavedPlacesCtrl', function ($scope, placesDataService, $modal) {

    $scope.gridOptions = {
        enableFiltering: true,
        enableSorting: true,
        showGridFooter: true,
        enableGridMenu: true,
        paginationPageSizes: [25, 100],
        paginationPageSize: 25,
        //exporterMenuCsv: false,
	    columnDefs: [
			{ field: 'VenueName', name: 'Place Name' },
            { field: 'Address' },
            { field: 'Category' },
            {
                field: 'Rating',
                cellTemplate: '<span class="badge">{{grid.appScope.gridOptions.data[rowRenderIndex].Rating}}</span>'
            },
			{
				name: 'Command',
				cellTemplate: '<i class="fa fa-fw fa-trash-o" title="Delete" message="Do you want to remove this item?" ' + 
					'data-ng-click="grid.appScope.deleteItem({{grid.appScope.gridOptions.data[rowRenderIndex].Id}});"></i>'
			}
	    ],
	};

	$scope.gridOptions.data = [];
	//paging
	$scope.totalRecordsCount = 0;
	$scope.pageSize = 10;
	$scope.currentPage = 1;

	init();

	function init() {
	    getUserPlaces();
	}

	function getUserPlaces() {

		var userInCtx = placesDataService.getUserInContext();
		debugger;
		userInCtx = userInCtx != null ? userInCtx : "Minh";
		if (userInCtx) {

		    placesDataService.getUserPlaces(userInCtx, $scope.currentPage - 1, $scope.pageSize).then(function (results) {
		        $scope.gridOptions.data = results.data;

				var paginationHeader = angular.fromJson(results.headers("x-pagination"));

				$scope.totalRecordsCount = paginationHeader.TotalCount;

			}, function (error) {
				alert(error.message);
			});
		}
	}


	$scope.deleteItem = function (venueId) {
		var modalInstance = $modal.open({
			templateUrl: '/Scripts/app/partials/ConfirmModal.html',
			controller: 'confirmModalCtrl',
			resolve: {
				title: function () {
					return "TITLE";
				},
				message: function() {
					return "DO YOU WANT TO DELETE THIS?";
				}
			}
		});
		modalInstance.result.then(function () {
			//Deletion Logic Code Here
		}, function () {
			//alert('Modal dismissed at: ' + new Date());
		});
	};

	$scope.pageChanged = function (page) {

		$scope.currentPage = page;
		getUserPlaces();

	};

});