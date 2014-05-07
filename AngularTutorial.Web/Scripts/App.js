angular.module("angularTutorial", ["ngRoute", "controllers"])
    .config(["$routeProvider", "$locationProvider",
        function ($routeProvider, $locationProvider) {
            $routeProvider
                .when('/lessons/:lessonId', {
                    templateUrl: '/Content/Views/Lesson.html',
                    controller: 'lesson'
                })
                .otherwise({
                    templateUrl: "/Content/Views/Home.html",
                    controller: "home",
                    title: "Home"
                });

            $locationProvider.html5Mode(false).hashPrefix('!');
        }
    ]);