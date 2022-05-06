import { __awaiter, __decorate, __generator, __metadata } from "tslib";
import { Component } from "@angular/core";
import { CountryClient } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
var CountryEditComponent = /** @class */ (function () {
    function CountryEditComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
    }
    CountryEditComponent.prototype.ngOnInit = function () {
        return __awaiter(this, void 0, void 0, function () {
            var id, data;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        id = this.route.snapshot.params['id'];
                        return [4 /*yield*/, this.service.getCountry(id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.item = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    CountryEditComponent.prototype.save = function () {
        return __awaiter(this, void 0, void 0, function () {
            var url;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.updateCountry(this.item).toPromise()];
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
    CountryEditComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    CountryEditComponent = __decorate([
        Component({
            selector: 'country-edit',
            templateUrl: './country-edit.component.html'
        }),
        __metadata("design:paramtypes", [CountryClient, ActivatedRoute, Router])
    ], CountryEditComponent);
    return CountryEditComponent;
}());
export { CountryEditComponent };
//# sourceMappingURL=country-edit.component.js.map