//window.app = angular.module('resourceManagerApp', ['ui.select2', 'ngTable', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities']);
window.app = angular.module('vNextApp', ['ui.bootstrap','ui.select2', 'toaster', 'ngRoute', 'ngResource', 'ngAnimate', 'custom-utilities']);
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
        .when('/Login', { templateUrl: '/Scripts/app/views/shared/Login.html' })
        .when('/Register', { templateUrl: '/Scripts/app/views/shared/Register.html' })
        .when('/About', { templateUrl: '/Scripts/app/views/about/About.html' })
        .when('/Contact', { templateUrl: '/Scripts/app/views/contact/Contact.html' })
        .when('/Resources', { templateUrl: '/Scripts/app/views/resources/Resources-ng-table.html', controller: 'ResourcesCtrl' })
        .when('/Resources/Add', { templateUrl: '/Scripts/app/views/resources/Add.html', controller: 'ResourceCtrl' })
        .when('/Resources/Edit/:resourceId', { templateUrl: '/Scripts/app/views/resources/Edit.html', controller: 'ResourceEditCtrl' })
        .when('/Resources/:resourceId', { templateUrl: '/Scripts/app/views/resources/Details.html', controller: 'ResourceCtrl' })
        .when('/Places', { templateUrl: '/Scripts/app/views/places/Places.html', controller: 'PlacesExplorerCtrl' })
		.when('/Places/MySavedPlaces', { templateUrl: '/Scripts/app/views/places/MySavedPlaces.html', controller: 'MySavedPlacesCtrl' })
        .when('/Home', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'HomeCtrl' })
        .when('/Error', { templateUrl: '/Scripts/app/views/shared/Error.html' })
        .otherwise({
            //redirectTo: '/Login'
        });

    // $httpProvider.interceptors.push('authorizationInterceptor');
    // $httpProvider.interceptors.push('httpInterceptor');
}]).factory("userProfileSvc", function () {
    return {};
});

window.utilities = angular.module("custom-utilities", []);
