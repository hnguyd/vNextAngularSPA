'use strict';
app.controller('MySavedPlacesCtrl', function ($scope, placesDataService) {

    $scope.gridOptions = {
        enableFiltering: true,
        enableSorting: true,
        showGridFooter: true,
        enableGridMenu: true,
        paginationPageSizes: [25, 100],
        paginationPageSize: 25,
        //exporterMenuCsv: false,
	    columnDefs: [
            { field: 'VenueName', name: 'Place Name'},
            { field: 'Address' },
            { field: 'Category' },
            {
                field: 'Rating',
                cellTemplate: '<span class="badge">{{grid.appScope.gridOptions.data[rowRenderIndex].Rating}}</span>'
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

	$scope.pageChanged = function (page) {

		$scope.currentPage = page;
		getUserPlaces();

	};

});