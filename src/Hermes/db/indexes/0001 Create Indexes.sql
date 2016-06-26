CREATE INDEX emp_department_ix
       ON Employee (DepartmentId);

CREATE INDEX emp_job_ix
       ON Employee (JobId);

CREATE INDEX emp_manager_ix
       ON Employee (ManagerId);

CREATE INDEX emp_name_ix
       ON Employee (LastName, FirstName);

CREATE INDEX dept_location_ix
       ON Department (LocationId);

CREATE INDEX loc_city_ix
       ON Location (City);

CREATE INDEX loc_state_province_ix
    ON Location (StateProvince);
