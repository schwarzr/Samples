import { __awaiter, __decorate, __generator, __metadata } from "tslib";
import { Component } from "@angular/core";
import { CountryClient, CountryListItem } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
var CountryCreateComponent = /** @class */ (function () {
    function CountryCreateComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
        this.item = new CountryListItem();
    }
    CountryCreateComponent.prototype.save = function () {
        return __awaiter(this, void 0, void 0, function () {
            var url;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.insertCountry(this.item).toPromise()];
                    case 1:
                        _a.sent();
                        url = this.getNavUrl(this.route);
                        return [4 /*yield*/, this.router.navigateByUrl(url)];
                    case 2:
                        _a.sent();
                        return [2 /*return*/];
                }
            });
        });
    };
    CountryCreateComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    CountryCreateComponent = __decorate([
        Component({
            selector: 'country-create',
            templateUrl: './country-edit.component.html'
        }),
        __metadata("design:paramtypes", [CountryClient, ActivatedRoute, Router])
    ], CountryCreateComponent);
    return CountryCreateComponent;
}());
export { CountryCreateComponent };
//# sourceMappingURL=country-create.component.js.map