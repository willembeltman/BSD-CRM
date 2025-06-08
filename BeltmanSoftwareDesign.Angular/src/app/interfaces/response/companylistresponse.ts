import { Company } from "../company";
import { State } from "../state";

export interface CompanyListResponse {
    companies: Company[] | null;
    success: boolean;
    errorAuthentication: boolean;
    errorItemNotFound: boolean;
    state: State | null;
}