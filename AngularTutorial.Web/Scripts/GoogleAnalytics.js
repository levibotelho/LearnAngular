angular.module("services", [])
    .factory("navigationService", ["$http", function ($http) {
        var tableOfContents = function () {
            $http.get("/Home/GetTableOfContents")
                .success(function (data) {
                    $scope.tableOfContents = data;
                })
                .error(function () {
                    alert("An unexpected error has occured. Please try again.");
                });
        }();

        var setSelectedLesson = function (id) {
            for (var i = 0; i < tableOfContents.length; i++) {
                var module = tableOfContents[i];
                for (var j = 0; j < module.Lessons.length; j++) {
                    var lesson = module.Lessons[j];
                    if (lesson.Id == id) {
                        selectedLesson = lesson;
                        return;
                    }
                }
            }
        };

        var selectedLesson;
    }]);