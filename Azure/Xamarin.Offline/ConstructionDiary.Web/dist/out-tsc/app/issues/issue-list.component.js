import { __awaiter, __decorate, __generator, __metadata } from "tslib";
import { Component } from "@angular/core";
import { IssueClient } from '../../../src/service/service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';
var IssueListComponent = /** @class */ (function () {
    function IssueListComponent(service, currentRoute) {
        var _this = this;
        this.service = service;
        this.currentRoute = currentRoute;
        currentRoute.data.pipe(map(function (p) { return p.project; }))
            .subscribe(function (p) { return _this.loadData(p); });
    }
    IssueListComponent.prototype.loadData = function (project) {
        return __awaiter(this, void 0, void 0, function () {
            var data;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0: return [4 /*yield*/, this.service.getIssues(project.id).toPromise()];
                    case 1:
                        data = _a.sent();
                        this.items = data;
                        return [2 /*return*/];
                }
            });
        });
    };
    IssueListComponent = __decorate([
        Component({
            selector: 'issue-list',
            templateUrl: './issue-list.component.html'
        }),
        __metadata("design:paramtypes", [IssueClient, ActivatedRoute])
    ], IssueListComponent);
    return IssueListComponent;
}());
export { IssueListComponent };
//# sourceMappingURL=issue-list.component.js.map