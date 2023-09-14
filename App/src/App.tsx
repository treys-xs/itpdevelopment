import {Route, Routes} from "react-router-dom";
import {ProjectsPage} from "./pages/ProjectsPage";
import {TaskDetailPage} from "./pages/TaskDetailPage";
import {TasksPage} from "./pages/TasksPage";

function App() {
    return(
        <Routes>
            <Route path="/" element={<ProjectsPage/>}/>
            <Route path=":name/tasks" element={<TasksPage/>}/>
            <Route path="task/:id" element={<TaskDetailPage/>}/>
        </Routes>
    );
}

export default App;
