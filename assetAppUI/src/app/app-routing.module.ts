import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SiteListComponent } from './sites/site-list/site-list.component';
import { SiteDetailComponent } from './sites/site-detail/site-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { VendorListComponent } from './vendors/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './vendors/vendor-detail/vendor-detail.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { CategoryDetailComponent } from './categories/category-detail/category-detail.component';
import { ReportListComponent } from './reports/report-list/report-list.component';
import { ReportDetailComponent } from './reports/report-detail/report-detail.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'sites', component: SiteListComponent},
    {path: 'sites/:id', component: SiteDetailComponent},
    {path: 'vendors', component: VendorListComponent},
    {path: 'vendors/:id', component: VendorDetailComponent},
    {path: 'categories', component: CategoryListComponent},
    {path: 'categories/:id', component: CategoryDetailComponent},
    {path: 'messages', component: MessagesComponent},
    {path: 'reports', component: ReportListComponent},
    {path: 'reports/:id', component: ReportDetailComponent},
    ]
  },
  
  {path: '**', component: HomeComponent, pathMatch: 'full'}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
    CommonModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
