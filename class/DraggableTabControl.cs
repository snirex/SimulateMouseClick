using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace SimulateMouseClick
//{
public class DraggableTabControl : TabControl
{
    private TabPage predraggedTab;
    public DraggableTabControl()
    {
        AllowDrop = true;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        predraggedTab = GetPointedTab();
        base.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        predraggedTab = null;
        base.OnMouseUp(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && predraggedTab !=null)
        {
            this.DoDragDrop(predraggedTab, DragDropEffects.Move);
        }
        base.OnMouseMove(e);
    }

    protected override void OnDragOver(DragEventArgs drgevent)
    {
        TabPage draggedTab = (TabPage)drgevent.Data.GetData(typeof(TabPage));
        TabPage pointedTab = GetPointedTab();
        if (draggedTab == predraggedTab && pointedTab != null)
            drgevent.Effect = DragDropEffects.Move;

        if (pointedTab != draggedTab)
            SwapTabPages(draggedTab, pointedTab);

        base.OnDragOver(drgevent);
    }

    private TabPage GetPointedTab() {
        for (int i = 0; i < this.TabPages.Count; i++)
        {
            if (this.GetTabRect(i).Contains(this.PointToClient(Cursor.Position)))
                return this.TabPages[i];
        }
        return null;
    }

    private void SwapTabPages(TabPage src, TabPage dst)
    {
        int src_i = this.TabPages.IndexOf(src);
        int dst_i = this.TabPages.IndexOf(dst);

        this.TabPages[dst_i] = src;
        this.TabPages[src_i] = dst;

        if (this.SelectedIndex == src_i)
            this.SelectedIndex = dst_i;
        else if (this.SelectedIndex == dst_i)
            this.SelectedIndex = src_i;

        this.Refresh();
    }


}
//}
