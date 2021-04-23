import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { SiteListComponent } from './sites/site-list/site-list.component';
import { SiteDetailComponent } from './sites/site-detail/site-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { VendorListComponent } from './vendors/vendor-list/vendor-list.component';
import { VendorDetailComponent } from './vendors/vendor-detail/vendor-detail.component';
import { CategoryListComponent } from './categories/category-list/category-list.component';
import { CategoryDetailComponent } from './categories/category-detail/category-detail.component';
import { ReportListComponent } from './reports/report-list/report-list.component';
import { ReportDetailComponent } from './reports/report-detail/report-detail.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    SiteListComponent,
    SiteDetailComponent,
    MessagesComponent,
    VendorListComponent,
    VendorDetailComponent,
    CategoryListComponent,
    CategoryDetailComponent,
    ReportListComponent,
    ReportDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
