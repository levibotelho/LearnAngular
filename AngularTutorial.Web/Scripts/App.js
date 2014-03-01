angular.module("angularTutorial", ["ngRoute", "controllers"])
    .config(["$routeProvider", "$locationProvider",
        function ($routeProvider, $locationProvider) {
            $routeProvider
                .when('/lessons/:lessonId', {
                    templateUrl: '/Content/Views/Lesson.html',
                    controller: 'lesson'
                })
                .when("/about", {
                    templateUrl: "/Content/Views/About.html",
                    controller: "about"
                })
                .otherwise({ redirectTo: "/lessons/introducing-angular" });

            $locationProvider.html5Mode(false).hashPrefix('!');
        }
    ]);