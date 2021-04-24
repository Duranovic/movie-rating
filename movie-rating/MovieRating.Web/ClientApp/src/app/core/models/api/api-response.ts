import { PaginationInfo } from '../pagination/pagination-info';

export interface ApiResponse<TEntity> {
	records: TEntity;
	paginationInfo: PaginationInfo;
}

export interface ApiResponsePayload<TEntity> {
	records: { payload: TEntity };
	paginationInfo: PaginationInfo;
}