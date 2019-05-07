import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
import { CountryClient } from '../../service/service';
var CountriesListComponent = /** @class */ (function () {
    function CountriesListComponent(service) {
        this.service = service;
    }
    CountriesListComponent.prototype.ngOnInit = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var data;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.getCountryListItems().toPromise()];
                    case 1:
                        data = _a.sent();
                        this.items = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    CountriesListComponent.prototype.select = function (item) {
        this.selectedItem = item;
    };
    CountriesListComponent.prototype.delete = function (item) {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.deleteCountry(item.id).toPromise()];
                    case 1:
                        _a.sent();
                        return [4 /*yield*/, this.ngOnInit()];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    CountriesListComponent = tslib_1.__decorate([
        Component({
            selector: 'countries-list',
            templateUrl: './countries-list.component.html'
        }),
        tslib_1.__metadata("design:paramtypes", [CountryClient])
    ], CountriesListComponent);
    return CountriesListComponent;
}());
export { CountriesListComponent };
//# sourceMappingURL=countries-list.component.js.map