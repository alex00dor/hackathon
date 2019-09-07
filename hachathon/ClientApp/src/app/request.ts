export class Request {

  constructor(
    public id: number,
    public firstName: string,
    public lastName: string,
    public address: string,
    public city: string,
    public state: string,
    public zip: number,
    public email: string,
    public phone: number,
    public plan: string,
    public ssn: number
  ) {  }

}
