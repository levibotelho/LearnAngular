angular.module("angularTutorial", ["ngRoute", "controllers"])
    .config(["$routeProvider", "$locationProvider",
        function ($routeProvider, $locationProvider) {
            $routeProvider
                .when('/lessons/:lessonId', {
                    templateUrl: '/Content/Views/Lesson.html',
                    controller: 'lesson'
                })
                .when("/lessons", {
                    redirectTo: "/lessons/introducing-angular"
                })
                .when("/feedback", {
                    templateUrl: "/Content/Views/Feedback.html",
                    controller: "feedback",
                    title: "Feedback"
                })
                .otherwise({
                    templateUrl: "/Content/Views/Home.html",
                    controller: "home",
                    title: "Home"
                });

            $locationProvider.html5Mode(false).hashPrefix('!');
        }
    ]);