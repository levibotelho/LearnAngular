angular.module("angularTutorial", ["ngRoute", "controllers"])
    .config(["$routeProvider", "$locationProvider",
        function ($routeProvider, $locationProvider) {
            $routeProvider.
              when('/lessons/:lessonId', {
                  templateUrl: '/Content/Views/Lesson.html',
                  controller: 'lesson'
              }).
              otherwise({redirectTo: "/lessons/cceefa09-dac9-42b1-b4b1-d74abacda62b"});

            $locationProvider.html5Mode(false).hashPrefix('!');
        }
    ]);