//window.app = angular.module('resourceManagerApp', ['ui.select2', 'ngTable', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities']);
window.app = angular.module('vNextApp', ['ui.bootstrap', 'ui.grid', 'ui.grid.edit', 'ui.grid.exporter', 'ui.grid.pagination', 'ui.grid.selection', 'ui.select2',
	'angular-loading-bar', 'ngRoute', 'ngResource', 'ngAnimate', 'ngTouch',
	'toaster']);
app.config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', function ($routeProvider, $locationProvider, $httpProvider, $provide) {
    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    //$httpProvider.defaults.useXDomain = true;

    $locationProvider.html5Mode({
        enabled: true,
        // requireBase: false
    });
    $routeProvider
        .when('/', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'HomeCtrl' })
        .when('/About', { templateUrl: '/Scripts/app/views/about/About.html' })
        .when('/Contact', { templateUrl: '/Scripts/app/views/contact/Contact.html' })
        .when('/Places', { templateUrl: '/Scripts/app/views/places/Places.html', controller: 'PlacesExplorerCtrl' })
		.when('/Places/MySavedPlaces', { templateUrl: '/Scripts/app/views/places/MySavedPlaces.html', controller: 'MySavedPlacesCtrl' })
        .when('/Home', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'HomeCtrl' })
        .when('/Error', { templateUrl: '/Scripts/app/views/shared/Error.html' })
        .otherwise({
            redirectTo: '/Error'
        });
}]);