angular.module("services", [])
    .factory("navigationFactory", ["$http", function ($http) {
        return {
            selectedModuleId: "",
            selectedLesson: null,
            getTableOfContents: function () {
                return $http.get("/Home/GetTableOfContents", { cache: true });
            },
            setSelectedLesson: function (id) {
                this.getTableOfContents()
                    .success(function (tableOfContents) {
                        for (var i = 0; i < tableOfContents.length; i++) {
                            var module = tableOfContents[i];
                            for (var j = 0; j < module.Lessons.length; j++) {
                                var lesson = module.Lessons[j];
                                if (lesson.Id == id) {
                                    self.selectedModuleId = module.Id;
                                    self.selectedLesson = lesson;
                                    return;
                                }
                            }
                        }
                    })
                    .error(function () {
                        alert("An unexpected error has occurred. Please try again.");
                    });
            }
        };
    }]);