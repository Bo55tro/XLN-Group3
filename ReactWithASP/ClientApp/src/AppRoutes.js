
import { Home } from "./components/Home";
import RankItems from "./components/RankItems";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/rank-items',
    element: <RankItems />
  }
];

export default AppRoutes;
