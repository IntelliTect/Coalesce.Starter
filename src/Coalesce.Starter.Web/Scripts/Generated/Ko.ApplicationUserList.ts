/// <reference path="../../typings/tsd.d.ts" />
/// <reference path="../Coalesce/intellitect.utilities.ts" />
/// <reference path="../Coalesce/intellitect.ko.utilities.ts" />
/// <reference path="./Ko.ApplicationUser.ts" />

// Knockout List View Model for: ApplicationUser
// Auto Generated Knockout List Bindings
// Copyright IntelliTect, 2017

var baseUrl = baseUrl || '';

module ListViewModels {

    // Add an enum for all methods that are static and IQueryable
    export enum ApplicationUserDataSources {
            Default,
        }
    export class ApplicationUserList extends BaseListViewModel<ApplicationUserList, ViewModels.ApplicationUser> {
        protected modelName = "ApplicationUser";
        protected areaUrl = ((true) ? baseUrl : baseUrl + '/');
        protected apiUrlBase = "api/ApplicationUser";
        public modelKeyName = "applicationUserId";
        public dataSources = ApplicationUserDataSources;
        public itemClass = ViewModels.ApplicationUser;

        public query: {
            where?: string;
            applicationUserId?:number;
            name?:String;
        } = null;

        // The custom code to run in order to pull the initial datasource to use for the collection that should be returned
        public listDataSource: ApplicationUserDataSources = ApplicationUserDataSources.Default;

        // Valid values
    
        protected createItem = (newItem?: any, parent?: any) => new ViewModels.ApplicationUser(newItem, parent);

        constructor() {
            super();
            var self = this; 

    // Method Implementations
        }
    }

    export namespace ApplicationUserList {
        // Classes for use in method calls to support data binding for input for arguments
    }
}