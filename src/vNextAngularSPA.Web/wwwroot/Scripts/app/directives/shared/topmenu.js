"use strict";
app.directive('cstTopMenu', [function () {
    return {
    	restrict: 'A',
    	scope: {
			username: '@username',
			showlogoff: '@showlogoff'
    	},
        replace: true,
        templateUrl: '/Scripts/app/partials/TopMenu.html',
        link: function (scope, element, attrs, ngModelCtrl) {
            var menuItems = element.find("a");
            menuItems.on('click', function () {
                menuItems.removeClass('active');
                $(this).addClass('active');
            });

            scope.$on('logOff', function () { 
                scope.isAuthenticated = false;
            });

            scope.$on('logOn', function () { 
                scope.isAuthenticated = true;
            });
        }
    };
}]);