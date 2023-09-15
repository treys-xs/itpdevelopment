import axios from 'axios'
import {serverApi} from "../../../constants/serverApi";

export async function GetTasksServer(nameProject? : string){
    return await axios.get(`${serverApi}/task/getall/${nameProject}`)
}