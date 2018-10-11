import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CORE_CONFIG_TOKEN, ICoreConfig } from '../../../core/core.config';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { ProductDeleteCommand, Product, ProductEditCommand, ProductCreateCommand } from './model/product.model';

import { BaseService } from '../../../core/utils';
import { AbstractResolveService } from '../../../core/utils/abstract-resolve.service';
import { NDDBreadcrumbService } from '../../../shared/ndd-ng-breadcrumb';

@Injectable()
export class ProductQueryService extends BehaviorSubject<any> {

    public api: string;

    constructor(private http: HttpClient) {
        super(null);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public getAll(filterValue: string): void {

        return this.fetch(filterValue)
          .subscribe((x: BehaviorSubject<any>) => super.next(x));
    }

    private fetch(filterValue: string): any {
        const queryStr: string = `$skip=0&$count=true&$filter=contains(tolower(CategoryName), tolower('${filterValue}'))`;

        return this.http
          .get(`${this.api}?${queryStr}`)
          .pipe(map((response: any) => response.value));
    }
}

@Injectable()
export class ProductService extends BaseService {

    public api: string;

    constructor(public httpClient: HttpClient,
        @Inject(CORE_CONFIG_TOKEN) config: ICoreConfig) {
        super(httpClient);
        this.api = `${config.apiEndpoint}api/products`;
    }

    public delete(cmd: ProductDeleteCommand): Observable<boolean> {
        return super.deleteRequestWithBody(this.api, cmd);
    }

    public get(id: number): Observable<Product> {
        return this.http.get(`${this.api}/${id}`).map((response: Product) => {
            response.manufacture = new Date(response.manufacture);
            response.expiration = new Date(response.expiration);

            return response;
        });
    }

    public put(cmd: ProductEditCommand): Observable<boolean> {
        return this.http.put(this.api, cmd).map((response: boolean) => response);
    }

    public post(cmd: ProductCreateCommand): Observable<boolean> {
        return this.http.post(this.api, cmd).map((response: boolean) => response);
    }
}

@Injectable()
export class ProductResolveService extends AbstractResolveService<Product> {
    constructor(private productService: ProductService,
        private breadcrumbService: NDDBreadcrumbService,
        router: Router) {
        super(router);
        this.paramsProperty = 'productId';
    }

    protected loadEntity(productId: number): Observable<Product> {
        return this.productService
            .get(productId)
            .take(1)
            .do((product: Product) => {
                this.breadcrumbService.setMetadata({
                    id: 'product',
                    label: product.name,
                    sizeLimit: true,
                });
            });
    }
}
