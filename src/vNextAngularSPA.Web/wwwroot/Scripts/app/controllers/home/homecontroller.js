//app.controller('HomeCtrl', ['$scope', 'resourceSvc', function ($scope, resourceSvc) {
app.controller('HomeCtrl', ['$scope', function ($scope) {
    init();
    function init() {
    	loadResources();
    }
    function loadResources() {
        //$scope.resources = resourceSvc.getTopFiveResources();
    }
}]);