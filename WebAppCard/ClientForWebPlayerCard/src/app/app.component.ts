import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'the-shop',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Web Card Shop';
  client_env_name : string = environment.env_name ;
  server_env_name : string = "";
}
