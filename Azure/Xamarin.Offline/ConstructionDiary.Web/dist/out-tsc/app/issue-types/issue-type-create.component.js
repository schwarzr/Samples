import * as tslib_1 from "tslib";
import { Component } from "@angular/core";
import { IssueClient, IssueTypeListItem } from '../../service/service';
import { ActivatedRoute, Router } from '@angular/router';
var IssueTypeCreateComponent = /** @class */ (function () {
    function IssueTypeCreateComponent(service, route, router) {
        this.service = service;
        this.route = route;
        this.router = router;
        this.item = new IssueTypeListItem();
    }
    IssueTypeCreateComponent.prototype.save = function () {
        return tslib_1.__awaiter(this, void 0, void 0, function () {
            var url;
            return tslib_1.__generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.insertIssueType(this.item).toPromise()];
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
    IssueTypeCreateComponent.prototype.getNavUrl = function (route) {
        var items = route.parent.snapshot.pathFromRoot;
        return items.map(function (p) { return p.url.join('/'); }).join('/');
    };
    IssueTypeCreateComponent = tslib_1.__decorate([
        Component({
            selector: 'issue-type-create',
            templateUrl: './issue-type-edit.component.html'
        }),
        tslib_1.__metadata("design:paramtypes", [IssueClient, ActivatedRoute, Router])
    ], IssueTypeCreateComponent);
    return IssueTypeCreateComponent;
}());
export { IssueTypeCreateComponent };
//# sourceMappingURL=issue-type-create.component.js.map