import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
import { IssueClient } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
var IssueTypeEditComponent = /** @class */ (function () {
    function IssueTypeEditComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
    }
    IssueTypeEditComponent.prototype.ngOnInit = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var id, data;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        id = this.route.snapshot.params['id'];
                        return [4 /*yield*/, this.service.getIssueType(id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.item = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    IssueTypeEditComponent.prototype.save = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var url;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.updateIssueType(this.item).toPromise()];
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
    IssueTypeEditComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    IssueTypeEditComponent = tslib_1.__decorate([
        Component({
            selector: 'country-edit',
            templateUrl: './issue-type-edit.component.html'
        }),
        tslib_1.__metadata("design:paramtypes", [IssueClient, ActivatedRoute, Router])
    ], IssueTypeEditComponent);
    return IssueTypeEditComponent;
}());
export { IssueTypeEditComponent };
//# sourceMappingURL=issue-type-edit.component.js.map