/// <reference path="../../typings/tsd.d.ts" />
/// <reference path="../Coalesce/intellitect.utilities.ts" />
/// <reference path="../Coalesce/intellitect.ko.utilities.ts" />
/// <reference path="./Ko.ApplicationUser.ts" />

// Knockout List View Model for: ApplicationUser
// Auto Generated Knockout List Bindings
// Copyright IntelliTect, 2017

var baseUrl = baseUrl || '';

module ListViewModels {
    export var areaUrl = areaUrl || ((true) ? baseUrl : baseUrl + '/');
    // Add an enum for all methods that are static and IQueryable
    export enum ApplicationUserDataSources {
            Default,
        }
    export class ApplicationUserList {
        // Query string to limit the list of items.
        public queryString: string = "";
        // Object that is passed as the query parameters.
        public query: any = null;
        // The custom code to run in order to pull the initial datasource to use for the collection that should be returned
        public listDataSource: ApplicationUserDataSources = ApplicationUserDataSources.Default;
        // String the represents the child object to load 
        public includes: string = "";
        // Whether or not alerts should be shown when loading fails.
        public showFailureAlerts: boolean = true;
        // List of items. This the main collection.
        public items: KnockoutObservableArray<ViewModels.ApplicationUser> = ko.observableArray([]);
        // Load the list.
		public load: (callback?: any) => void;
        // Adds a new item to the collection.
		public addNewItem: () => ViewModels.ApplicationUser;
        // Deletes an item.
		public deleteItem: (item: ViewModels.ApplicationUser) => void;
        // True if the collection is loading.
		public isLoading: KnockoutObservable<boolean> = ko.observable(false);
        // Gets the count of items without getting all the items. Data put into count.
		public getCount: (callback?: any) => void;
        // The result of getCount() or the total on this page.
		public count: KnockoutObservable<number> = ko.observable(null);
        // Total count of items, even ones that are not on the page.
   		public totalCount: KnockoutObservable<number> = ko.observable(null);
        // Total page count
   		public pageCount: KnockoutObservable<number> = ko.observable(null);
        // Page number. This can be set to get a new page.
   		public page: KnockoutObservable<number> = ko.observable(1);
        // Number of items on a page.
   		public pageSize: KnockoutObservable<number> = ko.observable(10);
        // If a load failed, this is a message about why it failed.
   		public message: KnockoutObservable<string> = ko.observable(null);
        // Search criteria for the list. This can be exposed as a text box for searching.
   		public search: KnockoutObservable<string> = ko.observable("");
        // Specify the DTO that should be returned - must be a fully qualified type name
        public dto: KnockoutObservable<string> = ko.observable("");
        // If there is another page, this is true.
        public nextPageEnabled: KnockoutComputed<boolean>
        // If there is a previous page, this is true.
        public previousPageEnabled: KnockoutComputed<boolean>;
        // Gets the next page.
        public nextPage: () => void;
        // Gets the previous page.
        public previousPage: () => void;
        // Control order of results
        public orderBy: KnockoutObservable<string> = ko.observable("");
        public orderByDescending: KnockoutObservable<string> = ko.observable("");

        // True once the data has been loaded.
		public isLoaded: KnockoutObservable<boolean> = ko.observable(false);

        // Valid values
            constructor() {
            var self = this; 
            var searchTimeout: number = 0;

            // Load the collection
            self.load = function(callback?: any) {
                intellitect.utilities.showBusy();
                if(self.query) {
                    self.queryString = $.param(self.query);
                }
                self.isLoading(true);

                var url = areaUrl + "api/ApplicationUser/List?includes=" + self.includes + "&page=" + self.page()
                            + "&pageSize=" + self.pageSize() + "&search=" + self.search()
                            + "&orderBy=" + self.orderBy() + "&orderByDescending=" + self.orderByDescending()
                            + "&listDataSource=";
    
                if (typeof self.listDataSource === "string") url += self.listDataSource;
                else url += ApplicationUserDataSources[self.listDataSource];

                if (self.queryString !== null && self.queryString !== "") url += "&" + self.queryString;

                $.ajax({ method: "GET",
                         url: url,
                        xhrFields: { withCredentials: true } })
                .done(function(data) {
                    self.items.removeAll();
                    for (var i in data.list) {
                        var model = new ViewModels.ApplicationUser(data.list[i]);
                        model.includes = self.includes;
                        model.onDelete(itemDeleted);
                        self.items.push(model);
                    }
                    self.count(data.list.length);
                    self.totalCount(data.totalCount);
                    self.pageCount(data.pageCount);
                    self.page(data.page);
                    self.message(data.message)
                    self.isLoaded(true);
                    if ($.isFunction(callback)) callback(self);
                })
                .fail(function(xhr) {
                    var errorMsg = "Unknown Error";
                    if (xhr.responseJSON && xhr.responseJSON.message) errorMsg = xhr.responseJSON.message;
                    self.message(errorMsg);
                    self.isLoaded(false);
                    
                    if (self.showFailureAlerts)
                        alert("Could not get list of ApplicationUser items: " + errorMsg);
                })
                .always(function() {
                    intellitect.utilities.hideBusy();
                    self.isLoading(false);
                });
            };

            // Paging
            self.nextPage = function() {
                if (self.nextPageEnabled()) {
                    self.page(self.page() + 1);
                    self.load();
                }
            }
            self.nextPageEnabled = ko.computed(function() {
                if (self.page() < self.pageCount()) return true;
                return false;
            })
            self.previousPage = function() {
                if (self.previousPageEnabled()) {
                    self.page(self.page() - 1);
                    self.load();
                }
            }
            self.previousPageEnabled = ko.computed(function() {
                if (self.page() > 1) return true;
                return false;
            })


            // Load the count
            self.getCount = function(callback?: any) {
                intellitect.utilities.showBusy();
                if (self.query) {
                    self.queryString = $.param(self.query);
                }
                $.ajax({ method: "GET",
                         url: areaUrl + "api/ApplicationUser/count?" + "listDataSource=" + ApplicationUserDataSources[self.listDataSource] + "&" + self.queryString,
                         xhrFields: { withCredentials: true } })
                .done(function(data) {
                    self.count(data);
                    if ($.isFunction(callback)) callback();
                })
                .fail(function() {
                    if (self.showFailureAlerts)
                        alert("Could not get count of ApplicationUser items.");
                })
                .always(function() {
                    intellitect.utilities.hideBusy();
                });
            };

            // Callback for when an item is deleted
            function itemDeleted(item) {
                self.items.remove(item);
            }

            // Adds a new item to the array.
            self.addNewItem = function()
            {
                var item = new ViewModels.ApplicationUser();
                self.items.push(item);
                return item;
            };

            // Deletes an item and removes it from the array.
            self.deleteItem = function(item: ViewModels.ApplicationUser)
            {
                item.deleteItem();
            };

            self.pageSize.subscribe(function () {
                if (self.isLoaded()){
                    self.load();
                }
            });
            self.page.subscribe(function () {
                if (self.isLoaded() && !self.isLoading()){
                    self.load();
                }
            });
            self.search.subscribe(function () {
                if (searchTimeout) {
                    clearTimeout(searchTimeout);
                }
                searchTimeout = setTimeout(function() {
                    searchTimeout = 0;
                    self.load();
                }, 300);
            });

    // Method Implementations
        }
    }

    export namespace ApplicationUserList {
        // Classes for use in method calls to support data binding for input for arguments
    }
}